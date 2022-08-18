<template>
  <div class="main">
  <div id="menu" v-show= !login>
  <img v-on:click="showHideMenu" src="..\assets\hamburger-menu-icon.png" id="menu-icon">
  <div id="menu-list" v-if="showForm">
    <h2><router-link v-bind:to="{ name: 'home' }">HOME</router-link></h2>
    <h2><router-link v-bind:to="{ name: 'addpet' }">REGISTER A PET</router-link></h2>
    <h2><router-link v-bind:to="{ name: 'user-profile' }">PET PROFILE</router-link></h2>
    <h2><router-link v-bind:to="{ name: 'playdates' }">SCHEDULED PLAYDATES</router-link></h2>
    <h2><router-link v-bind:to="{name:'available-playDates'}">AVAILABLE PLAYDATES</router-link></h2>
    <h2><router-link v-bind:to="{ name: 'map' }">MAP</router-link></h2>
    <h2><router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">LOGOUT</router-link></h2>
    </div>
    </div>



    <div class="home">

      
    <h1 class="h3 mb-3 font-weight-normal" v-show="homePage||login">Welcome To Pet Play Pals!</h1>
    <div  v-show="!homePage&&!login">
      <p></p>
      <br>
    </div>
    <img src="..\assets\PawPrint.png" id="paw-print"><br>
  
  
  </div>
  <div id="user-profile" v-show= !login>
    <img src="..\assets\userprofileicon.jpg" id="user-profile-icon">
    Welcome, <i>{{this.$store.state.user.username}}</i>!
    </div>
  </div>
</template>

<script>
export default {
  name: "globalmenu",
  data() {
    return {
      showForm: false
      }
    },
  props: ['homePage','login'], 

  methods: {
    showHideMenu() {
      this.showForm = !this.showForm;
    }
  }
};
</script>

<style>
#app > div > div.main {
  display: grid;
  grid-template-columns:1fr 3fr 1fr ;
  grid-template-areas:
    "menu home welcome";
 
}
#app > div > div.main > div.home > h1
{
 color: #F0EEE4;
    font-weight: bold;
    text-shadow: black 2px 2px;
}

#menu {
  grid-area: menu;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  padding-right:0px;
  margin-right: 0px;
}
#menu-list {
  padding-top: 0px;
  margin-top: 0px;
}

#paw-print {
  margin-top: 0px;
  height:50px;
  width: auto;
  border-radius: 20%;
  margin-bottom: 20px;
}
#app > div > div.main > div.home
{
  background-image: url("../assets/grassbackgroundcropped2.jpg") !important;
    background-repeat:no-repeat;
    opacity: .75;
     grid-area: home;
     background-size: cover;
}
/* #home {
  
 
  padding-left:0px;
  margin-left: 0px;

} */
#user-profile{
 grid-area: welcome;
 display: flex;
 justify-content: flex-end;
}
#menu-user-profile {
  display: flex;
  
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

a:link {
  color: #878357
}
a:visited {
  color: #878357;
}
#body {
  padding-right: 200px;
}
</style>