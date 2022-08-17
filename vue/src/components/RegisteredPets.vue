<template>
<div>
    <h2 class="h3 mb-3 font-weight-normal">Your Registered pets</h2>
    <div id="isLoading" v-if="isLoading"><img src="https://c.tenor.com/qmg1JQ82uWAAAAAj/oxo-perros-cute.gif" /></div>
    <div v-show="!isLoading"><div id="noPets" v-show="noPets">You currently have no registered pets</div>
        <p><router-link v-show="noPets" v-bind:to="{ name: 'addpet' }">Click here to add a pet</router-link></p>
    </div>
    <div id="pets" v-show="!noPets">
    <div id="pet" v-for="pet in pet" v-bind:key="pet.petId"><img id="thumbnail" :src="pet.imageURL"><br><b><em>{{pet.name}},</em></b> {{pet.breed}} ({{pet.age}})<br><br></div>
    </div>
    <p><router-link v-bind:to="{ name: 'addpet' }">Click here to add a pet</router-link></p>
</div>  
</template>

<script>
import PetService from '../services/PetService';

export default {
    name: 'registered-pets',
    data() {
        return {
            pet: [
                { petId: 0,
                name: "",
                age: "",
                size: "",
                breed: "",
                temperament: "",
                energy: "",
                imageURL: "",
                bio: "" }
            ],
            noPets: true,
            isLoading: true,
           

        }
    },
  created() {
    PetService.getPets(this.$store.state.user.userId).then(response => {
      this.pet = response.data;
      this.$store.commit("SAVE_PETS", this.pet)
      if(!(this.pet.length === 0)) {
        this.noPets = false;
      }
      this.isLoading = false;
    });
  }
}

</script>

<style>
#reg-pets {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  width: 500px;
}

#isLoading > img {
  height: 100px;
  width: auto;
}

#thumbnail {
  height: 100px;
  width: auto;
}
</style>