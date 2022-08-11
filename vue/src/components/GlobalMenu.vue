<template>
  <div class="main">
  <div id="menu">
  <img v-on:click="showHideMenu" src="..\assets\hamburger-menu-icon.png" id="menu-icon">
  <div id="menu-list" v-if="showForm">
    <h2><router-link v-bind:to="{ name: 'home' }">HOME</router-link></h2>
    <h2><router-link v-bind:to="{ name: 'addpet' }">REGISTER A PET</router-link></h2>
    <h2>USER PROFILE</h2>
    <h2><router-link v-bind:to="{ name: 'playdates' }">PLAYDATES</router-link></h2>
    <h2>MAP</h2>
    <h2>FORUM</h2> 
    <h2><router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></h2>
    </div>
    </div>



    <div class="home">
    <div id="menu-user-profile">
    <div id="user-profile">
    <img src="..\assets\userprofileicon.jpg" id="user-profile-icon">
    Welcome, <i>{{this.$store.state.user.username}}</i>!
    </div>
    </div>

    <div id="body">
    <h1 class="h3 mb-3 font-weight-normal" v-show="homePage">Welcome To Pet Play Pals!</h1>
    
    <img src="..\assets\PawPrint.png" id="paw-print"><br>
    </div>
  </div>
  </div>
</template>

<script>
export default {
  name: "menu",
  data() {
    return {
      showForm: false
      }
    },
  props: ['homePage'], 
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
  grid-template-columns: 200px 3fr;
  grid-template-areas:
    "menu home";
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
  height:400px;
  width: auto;
}
#home {
  grid-area: home;
  padding-left:0px;
  margin-left: 0px;
}
#menu-user-profile {
  display: flex;
  justify-content: flex-end;
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
body > h1 {
  margin: 0px;
  padding: 0px;
}
a:link {
  color: #878357
}
a:visited {
  color: purple
}
#body {
  padding-right: 200px;
}
</style>