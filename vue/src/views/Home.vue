<template>
  <div class="main">
  <div id="menu">
  <img v-on:click="showHideMenu" src="..\assets\hamburger-menu-icon.png" id="menu-icon">
  <div id="menu-list" v-if="showForm">
    <h2>HELLO MENU!</h2>
    <h2>HOME</h2>
    <h2>REGISTERED PETS</h2>
    <h2>USER PROFILE</h2>
    <h2>PLAYDATES</h2>
    <h2>MAP</h2>
    <h2>FORUM</h2> 
    <h2><router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></h2>   
    </div></div>
  <div class="home">
    <div id="menu-user-profile">
    

    <div id="user-profile">
    <img src="..\assets\userprofileicon.jpg" id="user-profile-icon">
    Welcome, <i>{{this.$store.state.user.username}}</i>!
    </div>
    </div>

    <div id="body">
    <h1 class="h3 mb-3 font-weight-normal">Welcome To Pet Play Pals!</h1>
    
    <img src="..\assets\PawPrint.png" id="paw-print"><br>
    <div id="homepage-components">
    
    <div id="registered-pets">
    <registered-pets/> 
    </div>
    
    <div id="scheduled-playdates">
    <scheduled-play-dates/>
    </div>
    
    </div>
    </div>
    <!-- <p>You must be authenticated to see this</p> -->
  </div>
  </div>
</template>

<script>
import RegisteredPets from '../components/RegisteredPets.vue';
import ScheduledPlayDates from '../components/ScheduledPlayDates.vue';

export default {
  name: "home",
  data() {
    return {
      showForm: false
      }
    },
  components: {
    RegisteredPets,
    ScheduledPlayDates
  },
  methods: {
    showHideMenu() {
      this.showForm = !this.showForm;
    }
  }
};
</script>

<style>
#app > div.main {
  display: grid;
  grid-template-columns: 200px 3fr;
    grid-template-areas:
    "menu home";
}

#menu {
  grid-area: menu;
  display: flex;
  flex-direction: column;
  justify-content: start;
  padding-right:0px;
  margin-right: 0px;
}

#menu-list {
  padding-top: 0px;
  margin-top: 0px;
}

#home {
  grid-area: home;
  padding-left:0px;
  margin-left: 0px;
}

#menu-user-profile {
  display: flex;
  justify-content: end;
}

#menu-icon {
  height: 50px;
  width: 50px;
  text-align: left;
  display: flex;
  justify-content: left;
}


#user-profile-icon {
  height: 50px;
  width: auto;
}

#body {
  padding-right: 200px;
}

#homepage-components {
  display: flex;
  justify-content: center;
}

#registered-pets, #scheduled-playdates {
  background-color: #878357;
  color: white;
  width: 500px;
  height: 250px;
  margin: 75px;
}

#paw-print {
  height:400px;
  width: auto;
}

</style>
