<template>
<div>
    <h2 class="h3 mb-3 font-weight-normal">Your Registered pets</h2>
    <div v-if="pet.id === 0">You currently have no registered pets</div>
    <div id="pet" v-for="pet in pet" v-bind:key="pet.petId"><b><em>{{pet.name}},</em></b> {{pet.breed}} ({{pet.age}})</div>

</div>  
</template>

<script>
import PetService from '../services/PetService';

export default {
    name: 'registered-pets',
    data() {
        return {
            pet: [
                {petId: 0,
                name: "",
                age: "",
                size: "",
                breed: "",
                temperament: "",
                energy: "",
                bio: ""}
            ]
        }
    },
  created() {
    PetService.getPets(this.$store.state.user.userId).then(response => {
      this.pet = response.data;
    });
  }
}

</script>

<style>
pet {
    line-height: 1px;
}
</style>