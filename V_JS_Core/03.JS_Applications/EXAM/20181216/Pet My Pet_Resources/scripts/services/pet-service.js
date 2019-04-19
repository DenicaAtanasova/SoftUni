const petService = (() => {
  
    function getOtherPets(filter) {
      let query = filter && filter != 'Al' 
      ? {category:filter} 
      : {};
	  
	  query = Object.assign(query, {"_acl.creator":{"$ne": sessionStorage.id}});
      let endPoint = `pets?query=${JSON.stringify(query)}&sort={"likes": -1}`;
      return kinvey.get('appdata', endPoint, 'kinvey');
    }

    function getPets(userId) {
      let endPoint = `pets?query={"_acl.creator":"${userId}"}`;    
      return kinvey.get('appdata', endPoint, 'kinvey');
    }

    function getPet(petId) {
      let endPoint = `pets/${petId}`;    
      return kinvey.get('appdata', endPoint, 'kinvey');
    }

    function edit(data) {
      let endPoint = `pets/${data._id}`;    
      return kinvey.update('appdata', endPoint, 'kinvey', data);
    }
  
    function create(pet) {
      return kinvey.post('appdata', 'pets', 'kinvey', pet)
    }

    function remove(id) {  
      return kinvey.remove('appdata', `pets/${id}`, 'kinvey')
    }
  
    return {
        getOtherPets,
        getPets,
        getPet,
        create,
        remove,
        edit
    };
})();