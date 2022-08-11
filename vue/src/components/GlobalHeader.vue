<template>
    <div id="menu-user-profile">
    <div id="user-profile">
    <img src="..\assets\userprofileicon.jpg" id="user-profile-icon">
    Welcome, <i>{{this.$store.state.user.username}}</i>!
    </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>

</style>