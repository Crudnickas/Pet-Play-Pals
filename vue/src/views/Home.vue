<template>
  <div class="main">
  <div v-if="showForm" class="menu"><h1>HELLO MENU!</h1></div>
  <div class="home">
    <div id="menu-user-profile">
    
    <div id="menu">
    <img v-on:click="showHideMenu" src="..\assets\hamburger-menu-icon.png" id="menu-icon">
    </div>

    <div id="user-profile">
    <img src="..\assets\userprofileicon.jpg" id="user-profile-icon">
    Welcome, <i>Logged In User</i>!
    </div>
    </div>

    
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
  grid-template-columns: 1fr 4fr;
    grid-template-areas:
    "menu home";
}

#menu {
  grid-area: menu;
}

#home {
  grid-area: home;
}

#menu-user-profile {
  display: flex;
  justify-content: space-between;
}

#menu-icon {
  height: 50px;
  width: auto;
  text-align: left;
  display: flex;
  justify-content: left;
}

#user-profile-icon {
  height: 50px;
  width: auto;
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
