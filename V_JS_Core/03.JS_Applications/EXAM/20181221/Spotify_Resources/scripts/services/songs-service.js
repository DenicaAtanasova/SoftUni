const songService = (() => {

    function getAll(){
        let endPoint = `songs?query={}&sort={"likes": -1, "listened" : -1}`;
        return kinvey.get('appdata', endPoint, 'kinvey');
    };

    function getMy(userId){
        let endPoint = `songs?query={"_acl.creator":"${userId}"}&sort={"likes": -1, "listened" : -1}`;
        return kinvey.get('appdata', endPoint, 'kinvey');
    };

    function getSong(id) {
        return kinvey.get('appdata', `songs/${id}`, 'kinvey');
    }

    function create(song){
        return kinvey.post('appdata', 'songs', 'kinvey', song);
    };

    function update(id, data) {
        return kinvey.update('appdata', `songs/${id}`, 'kinvey', data);
    };

    function remove(id) {
        return kinvey.remove('appdata', `songs/${id}`, 'kinvey');
    };

    return {
        getAll,
        getMy,
        create,
        getSong,
        update,
        remove
    };

})();