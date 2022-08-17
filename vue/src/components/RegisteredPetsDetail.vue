<template>
<div>
    <h2 class="h3 mb-3 font-weight-normal">Your Registered pets</h2>
    <div id="isLoading" v-if="isLoading"><img src="https://c.tenor.com/qmg1JQ82uWAAAAAj/oxo-perros-cute.gif" /></div>
    <div v-show="!isLoading"><div id="noPets" v-show="noPets">You currently have no registered pets</div>

    </div>
    <div id="pets" v-show="!noPets">
    <div id="pet" v-for="SelectedPet in pet" v-bind:key="SelectedPet.petId">
      <img id="thumbnail" :src="SelectedPet.imageURL"><br>
      <label for="petName">Name: </label>
      <input id="petName" type="text" v-model="SelectedPet.name"/><br>
      
      <label for="petBreed">Breed: </label>
      <input id="petBreed" type="text" v-model="SelectedPet.breed"/><br>

      <label for="petAge">Age: </label>
      <input it="petAge" type="text" v-model="SelectedPet.age"/><br>

      <label for="petSize">Size: </label>
      <input it="petSize" type="text" v-model="SelectedPet.size"/><br>

      <label for="petTemp">Temperament: </label>
      <input it="petTemp" type="text" v-model="SelectedPet.temperament"/><br>

      <label for="petEnergy">Energy: </label>
      <input it="petEnergy" type="text" v-model="SelectedPet.energy"/><br>

      <label for="petImageURL">Image URL: </label>
      <input it="petImageURL" type="text" v-model="SelectedPet.imageURL"/><br>

      <label for="petBio">Bio: </label>
      <input it="petBio" type="text" v-model="SelectedPet.bio"/><br>

      <button class="submitButton" type="submit" v-on:click="updatePet(SelectedPet)">Update Pet</button>
      </div>
      </div>
    </div>
</template>

<script>
import PetService from '../services/PetService';

export default {
    name: 'registered-pets-detail',
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
    }, //end Data
  created() {
    PetService.getPets(this.$store.state.user.userId).then(response => {
      this.pet = response.data;
      this.$store.commit("SAVE_PETS", this.pet)
      if(!(this.pet.length === 0)) {
        this.noPets = false;
      }
      this.isLoading = false;
    });
  }, //end Created
  methods: {
      copyPetToStore(){
        // this.changingArrayToString;
        this.$store.commit("SETPETTOPOST", this.pet); 
    },
    updatePet(pet) {
      PetService.updatePet(pet).then(response => {
        if(response.status === 200) {
          alert(`Successully Updated ${pet.name}`)
          this.$router.push({path: '/'});
        }
      });
    }
  }
} //end Methods

</script>

<style>
#pet {
  margin: 20px;
}

#pets {
  display: flex;
}

#isLoading > img {
  height: 100px;
  width: auto;
}

#thumbnail {
  height: 100px;
  width: auto;
}

#pet > h3 {
  margin: 0px;
}
a:link {
    color: #F0EEE4;
    font-weight: bold;
}


</style>