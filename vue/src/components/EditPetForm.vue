<template>
<div>
{{pet.name}}
</div>  
</template>

<script>
import PetService from '../services/PetService';

export default {
    name: 'edit-pet-form',
    props: ['pet'], 
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