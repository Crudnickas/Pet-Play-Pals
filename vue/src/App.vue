<template>
  <div id="app">
    <!-- <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div> -->
    <router-view />
  </div>
</template>
<style>
@import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');


div{
  border-radius: 10px;
}
body {
background-color:#F0EEE4;
color: #878357;
font-family: 'Poppins', sans-serif;
cursor: url(https://cur.cursors-4u.net/nature/nat-8/nat738.cur), default !important;

}


a:link {
  color: #878357
  
}
a:visited{
color:rgb(78, 41, 14)
}
img{
  border-radius: 50%;
}
</style>

