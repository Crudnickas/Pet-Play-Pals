import axios from 'axios';

// const http = axios.create({
//   baseURL: "https://localhost:44315"
// });

export default {

  getPets(userID) {
    return axios.get(`/pet/userid/${userID}`); //this returns a Promise object
  },
  createPet(pet){
    return axios.put('/pet', pet);
  },
  createPetRelationship(relationship){
    return axios.post('/relationship', relationship);
  },
  getPetById(petId){
    return axios.get(`/pet${petId}`);
  },
  updatePet(pet){
    return axios.put(`/pet/${pet.petId}`, pet);
  }

 
}