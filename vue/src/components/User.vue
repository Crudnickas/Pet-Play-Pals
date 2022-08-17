<template>
<DIV>
  <h2 class="h3 mb-3 font-weight-normal">Your User Info</h2>
  <div id="user-component">
      <label for="username-text"><h3>Username:</h3></label>
      <input id="username-text" type="text" v-model="username" v-on:change="copyUsernameToStore"/>
      <button class="submitButton" type="submit" v-on:click="updateUsername">Update Username</button>
</div>
</DIV>
</template>


<script>
export default {
    name: 'user',
    data() {
        return{
            username: this.$store.state.user.username,
        } //end return
    }, //end data
    methods: {
        copyUsernameToStore() {
            this.$store.commit("SETUSERNAMETOPOST", this.username)
        },//end copyUsernameToStore
        updateUsername() {
            //THIS NEEDS COMPLETED!
        }
    }//end methods
}
</script>

<style>
#user-component {
    display: flex;
    align-items: center;
    justify-content: center;
}

#user-component > label {
    margin-right: 10px;
}

#user-info > div > h2 {
    margin: 10px;
}
</style>