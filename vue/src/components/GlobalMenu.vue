<template>
  <div id="menu">
  <img v-on:click="showHideMenu" src="..\assets\hamburger-menu-icon.png" id="menu-icon">
  <div id="menu-list" v-if="showForm">
    <h2>HELLO MENU!</h2>
    <h2>HOME</h2>
    <h2>REGISTER A PET</h2>
    <h2>USER PROFILE</h2>
    <h2>SCHEDULED PLAYDATES</h2>
    <h2>MAP</h2>
    <h2>FORUM</h2> 
    <h2><router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></h2>
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
  methods: {
    showHideMenu() {
      this.showForm = !this.showForm;
    }
  }
};
</script>

<style>
#menu {
  grid-area: menu;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  padding-right:0px;
  margin-right: 0px;
}
</style>