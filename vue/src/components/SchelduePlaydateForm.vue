<template>
<form class = "playdate-register">
<h2>Schedule a PlayDate:</h2>
<div id="selectYourPet">
 <label id="petDropDownLabel" for="petdropdown" class="sr-only">Select pets to attend playdate:  </label>

   <multiselect id ="multiselectTempDropdown"
          v-model=" selectedPetArray"
          @select="changingArrayToString"
          @close="changingArrayToString"
          :options="pets"
          label="name"
          :multiple="true"
          track-by="name"
          :close-on-select="false"
         >
          </multiselect>
</div>
<div>

        <label for="playDateLocation" class="sr-only">Select the location for the playdate: </label>
        <select name="playDateLocation" id="playDateLocation" v-model="SelectedLocation" > 
        <option disabled value = ""> Please Select one </option>
        <option
      v-for="location in $store.state. playDateLocations"
      v-bind:key="location.id">
     <b><em> {{location.PlayParkName}},    </em></b>{{location.PlayParkAddress}}
    </option>
        <p>>Notes about location: </p>
    </select>
    
 
        

    </div>


</form>

  
</template>

<script>
import Multiselect from 'vue-multiselect'
import PetService from '../services/PetService';

export default {
name: 'schedule-playdate-form',
components:{
    Multiselect
},
data(){
    return{
    selectedPetArray:[],
      pets: [
                { petId: 0,
                name: "",
                age: "",
                size: "",
                breed: "",
                temperament: "",
                energy: "",
                bio: "" }
            ],
         SelectedLocation : {
        PlayParkName: "",
        PlayParkAddress: "",
        PlayParkLocationNotes: ""
      }
    }
   
},
methods:{
    changingArrayToString(){
        this.pets.name=this.selectedPetArray.join(',');
    }
},
 created() {
    PetService.getPets(this.$store.state.user.userId).then(response => {
      this.pets = response.data;
    });

}
}

</script>
<style src="vue-multiselect/dist/vue-multiselect.min.css">
</style>

<style>
.multiselect{
width:20%;
color:#878357;
margin-right: 5px;
}
#selectYourPet{
    display:flex;
    justify-content: center;
}

</style>