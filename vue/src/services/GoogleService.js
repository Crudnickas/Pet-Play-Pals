import axios from 'axios';

const http = axios.create(); //create the axios instance, we're not using a base URL this time



export default {
    getLatLongFromAddress(address){
        //the API brings back a JSON object with a quote property
        
        return http.get(`https://maps.googleapis.com/maps/api/geocode/json?address=${address}&key=AIzaSyBOUUGE6iNOM-De1cMuo4WJflt8c2xetF4`, this.data, {
               })
  

}
}