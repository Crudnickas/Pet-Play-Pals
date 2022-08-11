import axios from 'axios';

// const http = axios.create({
//   baseURL: "https://localhost:44315"
// });

export default {

  getPlayDatesByUser(userID) {
    return axios.get(`/playdate/userid/${userID}`); //this returns a Promise object
  }
}