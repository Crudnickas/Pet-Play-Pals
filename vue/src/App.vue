<template>
  <div id="app">
    <div id="nav">
      <!-- <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp; -->
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />
  </div>
</template>
<style>
@import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');
body {
background-color:#F0EEE4;
color: #878357;
font-family: 'Poppins', sans-serif;

}
</style>

