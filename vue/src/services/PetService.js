import axios from 'axios';

// const http = axios.create({
//   baseURL: "https://localhost:44315"
// });

export default {

  getPets(userID) {
    return axios.get(`/pet/userid/${userID}`); //this returns a Promise object
  }
}