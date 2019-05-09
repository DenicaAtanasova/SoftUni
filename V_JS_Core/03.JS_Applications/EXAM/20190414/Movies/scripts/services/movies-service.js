const movieService = (() => {

    function getAll(){
        let endPoint = `movies?query={}&sort={"tickets": -1}`;
        return kinvey.get('appdata', endPoint, 'kinvey');
    };

    function getMy(userId){
        let endPoint = `movies?query={"_acl.creator":"${userId}"}&sort={"tickets": -1}`;
        return kinvey.get('appdata', endPoint, 'kinvey');
    };

    function getById(id) {
        return kinvey.get('appdata', `movies/${id}`, 'kinvey');
    }

    function create(movie){
        return kinvey.post('appdata', 'movies', 'kinvey', movie);
    };

    function update(id, data) {
        return kinvey.update('appdata', `movies/${id}`, 'kinvey', data);
    };

    function remove(id) {
        return kinvey.remove('appdata', `movies/${id}`, 'kinvey');
    };

    return {
        getAll,
        getMy,
        getById,
        create,
        update,
        remove
    };
})();