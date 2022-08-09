import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    dogBreeds: ["Australian Shepherd", "Beagle", "Bernese Mountain Dog","Boston Terrier","Boxer","Bulldog","Cane Corso","Cavalier King Charles Spaniel","Dachshund","Doberman Pinscher","French Bulldog","German Shepherd Dog","Golden Retriever","Great Dane","Havanese","Labrador Retriever","Miniature Schnauzer","Pembroke Welsh Corgi","Pointer (German Shorthaired)","Pomeranian","Poodle","Rottweiler","Shih Tzu","Siberian Huskie","Yorkshire Terrier"],
    petTemperament: ["Aggressive","Anxious","Bold","Calm","Friendly","Impulsive","Independent", "Naughty","Neutral","Passive", "Playful", "Timid" ],

    petEnergy: ["Low", "Medium", "High"],
    pets: []
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
  }
})
