handlers.getAllSongs = function(ctx){
    songService.getAll()
    .then(function(res){          
        res.forEach(song => 
            song.isCreator = song._acl.creator === sessionStorage.id                     
        );
        ctx.songs = res;
        loadPartials(ctx).then(function(){
            this.partial('/views/songs/allSongs.hbs')
        });
    })    
}

handlers.getMySongs = function(ctx){
    songService.getMy(sessionStorage.id)
    .then(function(res){          
        res.forEach(song => 
            song.isCreator = song._acl.creator === sessionStorage.id                     
        );
        ctx.songs = res;
        loadPartials(ctx).then(function(){
            this.partial('/views/songs/mySongs.hbs')
        });
    })
}

handlers.getCreate = function(ctx){
    loadPartials(ctx).then(function(){
        this.partial('/views/songs/create.hbs')
    });
}

handlers.createSong = function(ctx){
    let song = {...ctx.params, likes : 0, listened : 0};
    try {
        if (song.title.length < 6) {
            throw ('Song title must be at least 6 symbols');
        }
        if (song.artist.length < 3) {
            throw ('Song artist must be at least 3 symbols');
        }
        songService.create(song).then(function(){
            notify.showInfo('Song created successfully.');
            $('#title').val('');
            $('#artist').val('');
            $('#imageURL').val('');
        });
    } catch (err) {
        notify.showError(err);
    }     
}

handlers.likeSong = function (ctx) {
    let id = ctx.params.id;

    songService.getSong(id)
        .then(function (res) {
            let song = res;
            song.likes = Number(song.likes) + 1;
            
            songService.update(id, song)
                .then(function () {
                    notify.showInfo('Liked');
                    ctx.redirect('#/allSongs');
                });
        });
};

handlers.listenSong = function (ctx) {
    let id = ctx.params.id;

    songService.getSong(id)
        .then(function (res) {
            let song = res;
            song.listened = Number(song.listened) + 1;
            
            songService.update(id, song)
                .then(function () {
                    notify.showInfo(`You just listened ${song.title}`);                                      
                    ctx.redirect('#/allSongs');
                });
        });
};

handlers.deleteSong = function(ctx){
    let id = ctx.params.id;

    songService.remove(id)
        .then(function() {
            notify.showInfo('Song removed successfully!');
            ctx.redirect('#/allSongs');
        })
}