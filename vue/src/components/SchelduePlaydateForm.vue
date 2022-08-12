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
    </select>
    </div>
   
    <div id="datepicker">
   <label for="picker1" class="col-sm-3 control-label">
    Select Date and Time of PlayDate:
    </label>
    <div class="col-sm-5">
      <date-picker type="datetime" format="YYYY-MM-DDTHH:mm:ss" date-format="YYYY-MM-DDTHH:mm:ss" class="vue-picker1" name="picker1"
            v-model="playDate.playDateTimeDate" :confirm="true" valueType="format">
      </date-picker>
      
      </div>
      </div>
      
   


    
      
      <button type="submit" v-on:click.prevent="submitPlaydate">Submit</button>

 
   

</form>

  
</template>

<script>
import Multiselect from 'vue-multiselect'
import PetService from '../services/PetService';
import DatePicker from 'vue2-datepicker';
import 'vue2-datepicker/index.css';



export default {
name: 'schedule-playdate-form',
components:{
    Multiselect,
    DatePicker

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
      },
      
      playDate: {
          playDateID: 0,
          creatorID:0,
          playParkAddress: "",
          playParkName: "",
          playParkNotes: "",
          playDateTimeDate: "",

      }
     
    
    
    }
   
},
methods:{
    changingArrayToString(){
        this.pets.name=this.selectedPetArray.join(',');
    },
    

    submitPlaydate(){
              console.log(this.datetime);
              console.log(Date.parse(this.datetime));
              console.log(Date.parse(this.datetime).getMonth());
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
#datepicker
{
   display:flex;
    justify-content: center; 
}

</style>