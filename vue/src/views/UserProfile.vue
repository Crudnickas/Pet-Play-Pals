<template>
<div>
  <global-menu/>

    <div v-show="false"><h1>User Profile</h1></div>
 
    <div id="profile-components">
    
        <div v-show="false" id="user">
        <user/>
        </div>
        
        <div id="registered-pets-detail">
        <registered-pets-detail/> 
        </div>
    
    </div>
</div>
</template>

<script>
import GlobalMenu from '../components/GlobalMenu.vue'
import RegisteredPetsDetail from '../components/RegisteredPetsDetail.vue'
import User from '../components/User.vue'

export default {
  name: "user-profile",
  components: { GlobalMenu, RegisteredPetsDetail, User},

}
</script>


<style>
#profile-components {
  display: flex;
  flex-direction: column;
  align-items: center;
}

#user {
    display: flex;
    justify-content: center;
}

#user, #registered-pets-detail {
  background-color: rgb(137, 155, 83);
  color: white;
  min-width: 500px;
  min-height: 150px;
  margin: 20px 75px;
}
</style>