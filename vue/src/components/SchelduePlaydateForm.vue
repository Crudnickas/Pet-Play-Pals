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
        <select name="playDateLocation" id="playDateLocation" v-model="SelectedName" v-on:change="mappingSelectedLocation"> 
        <option disabled value = ""> Please Select one </option>
        <option
      v-for="location in $store.state.playDateLocations"
      v-bind:key="location.id" >
    {{location.PlayParkName}} 
    </option>
    </select>
    </div>
    <div>
      <p>Location Notes: {{this.playDate.playParkLocationNotes}}</p>
      </div>
      <div>
        <p> Location Address: {{this.playDate.playParkAddress}}</p>
        </div>

    <div>
      
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
      
   


    
      
      <button type="submit" v-on:click.prevent="submitPlaydate">Submit</button>&nbsp; 
      <button type="cancel" v-on:click.prevent="resetForm">Cancel</button>

 
   

</form>

  
</template>

<script>
import Multiselect from 'vue-multiselect'
import PetService from '../services/PetService';
import DatePicker from 'vue2-datepicker';
import 'vue2-datepicker/index.css';
import PlayDateServices from '../services/PlayDateServices';



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
            SelectedName: "",
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
          playParkLocationNotes: "",
          playDateTimeDate: "",

      },
      userPetPlaydateRelationship: {
      userID: 0,
      playDateID: 0,
      petID: 0,
      playDateStatus: "Available"
      }
     
    
    
    }
   
},
methods:{
    changingArrayToString(){
        this.pets.name=this.selectedPetArray.join(',');
      
    },
    

    submitPlaydate(){
      this.creatorID = this.$store.state.user.userId;
      PlayDateServices.createPlayDate(this.playDate)
      .then((response)=> {
        console.log("running");
        if(response.status === 201){
           this.playDate.playDateID= response.data.playDateID;
        

        this.selectedPetArray.forEach((element) =>{
        this.userPetPlaydateRelationship.playDateID=this.playDate.playDateID;
        this.userPetPlaydateRelationship.petID=element.petId;
        PlayDateServices.createrUserPlaydateRelationship(this.userPetPlaydateRelationship).then((response)=> {
          if(response.status === 200 ){
           console.log(`Successfully Added ${element.name}`);
          
          }

        })

      
          
        });
        alert("Your Playdate was successfully added! ")
          this.$router.push({
                path: '/',
               

              });
        

        }
      }).catch((error)=>{
        const response = error.response;
        if(response.status === 404){
          this.errorMessage=error.message;
        }

      });
    },
    mappingSelectedLocation(){
      this.SelectedLocation = this.$store.state.playDateLocations.filter((element)=> {
       return element.PlayParkName == this.SelectedName;

      })
      this.playDate.playParkAddress = this.SelectedLocation[0].PlayParkAddress;
      console.log(this.SelectedLocation[0].PlayParkAddress)
      this.playDate.playParkName = this.SelectedLocation[0].PlayParkName;
      this.playDate.playParkLocationNotes = this.SelectedLocation[0].PlayParkLocationNotes;
      

    
},

    resetForm() {
      this.playDate = {};
      this.SelectedName ="";
      this.selectedPetArray= [];
    },
 

},
 created() {
    PetService.getPets(this.$store.state.user.userId).then(response => {
      this.pets = response.data;
       this.playDate.creatorID = this.$store.state.user.userId;
        this.userPetPlaydateRelationship.userID = this.$store.state.user.userId;
    });
  

},

}

</script>
<style src="vue-multiselect/dist/vue-multiselect.min.css">
</style>

<style>
.multiselect{
width:40%;
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