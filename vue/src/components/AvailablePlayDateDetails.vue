<template>
<div>
    <div id="selectYourPet">
 <label id="petDropDownLabel" for="petdropdown" class="sr-only">Select the pet(s) you would like to join a playdate:  </label>

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
     <div id="playdates-container">
    <h1>Select a PlayDate to Join:</h1>
       <div id="playdate-div" v-for="playDate in playDate" v-bind:key="playDate.Id">
        <div id="thumbnail-div"><img id="thumbnail" :src="playDate.imageURL"><br>
        <b>{{playDate.petName}}</b></div>
        <b>Date & Time:</b> {{formatDate(playDate.playDateTimeDate)}}<br>
        <b>Location:</b> {{playDate.playParkName}} ({{playDate.playParkAddress}})<br>
        <b>Location Notes:</b> {{playDate.playParkLocationNotes}}
        <br>
    <button id= "joindatebutton" type="submit" v-on:click.prevent="UpdatingStatusofPlayDateToJoined(playDate.playDateID)">Join Play Date</button>&nbsp;

    </div>
</div>
</div>
  
</template>

<script>
import Multiselect from 'vue-multiselect'
import PlayDateServices from '../services/PlayDateServices'
import PetService from '../services/PetService';
export default {
    name: "available-play-date-details",
    components:{
         Multiselect
    },
    data(){
        return{
          playDate: [
            {
                playDateID:0,
                imageURL: "",
                creatorID:0,
                petName:"",
                playParkAddress:"",
                playParkName:"",
                playParkLocationNotes:"",
                playDateTimeDate: 0
                
            }
              ],
              playdatestatus: 'Available',
            playDateRelationshipToPut: {
                userID: 0,
                playDateID: 0,
                petID: 0,
                playDateStatus: "Joined"
            },
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
             userPetPlaydateRelationship: {
      userID: 0,
      playDateID: 0,
      petID: 0,
      playDateStatus: "Joined"
      }
              
        }

    },
    methods:{
        UpdatingStatusofPlayDateToJoined(playDateID){
            if(this.selectedPetArray.length == 0) {
                alert("Please select one or more pets to Join!");
                return;
            }
            this.playDateRelationshipToPut.playDateID = playDateID;
            PlayDateServices.updateUserPlayDateStatus(this.playDateRelationshipToPut)
            .then((response)=> {
                if(response.status === 200) {

            this.playDate.playDateID= response.data.playDateID;
        

        this.selectedPetArray.forEach((element) =>{
        this.userPetPlaydateRelationship.playDateID=playDateID;
        this.userPetPlaydateRelationship.petID=element.petId;
        PlayDateServices.createrUserPlaydateRelationship(this.userPetPlaydateRelationship).then((response)=> {
          if(response.status === 200 ){
           console.log(`Successfully Added ${element.name}`);
          
          }

        })

      
          
        });
                    alert("You have joined");
                     this.$router.push({
                path: '/',
                });
                }

        })
        .catch((error)=>{
        const response = error.response;
        if(response.status === 404){
          this.errorMessage=error.message;
        }
              });


    },
        changingArrayToString(){
        this.pets.name=this.selectedPetArray.join(',');
      
    },
        formatDate(dateToBeFormatted) {
        const date = new Date(dateToBeFormatted);
        let suffix = date.getHours() >= 12 ? "PM" : "AM";
        let hours = ((date.getHours()) % 12)
        if(hours===0) {
            hours = 12;
        }
        let minutes = date.getMinutes();
        let stringMinutes = "";
        if (minutes < 10) {
            stringMinutes = "0"+minutes; 
        } else {
            stringMinutes = minutes;
        }
        return `${date.getMonth() + 1}-${date.getDate()}-${date.getFullYear()} @ ${hours}:${stringMinutes} ${suffix}`;
        // getHours()}:${date.getMinutes()}:${date.getSeconds()}`; ${date.getHours()}
    }



    },
    created() {
    PlayDateServices.getPlayDatesByStatus(this.playdatestatus).then(response => {
      this.playDate = response.data.filter((element)=>{
          return element.creatorID != this.$store.state.user.userId;
      });
    });
        PetService.getPets(this.$store.state.user.userId).then(response => {
      this.pets = response.data;
       this.playDate.creatorID = this.$store.state.user.userId;
        this.userPetPlaydateRelationship.userID = this.$store.state.user.userId;
    });
  

},
    
    

}
</script>

<style scoped>
#playdate-div {
    background-color: #878357;
    color: #F0EEE4;
    margin: 20px 20px;
    width: 700px;
    text-align: center;
    padding: 15px;
}
#thumbnail-div {
    text-align: center;
}
#thumbnail {
    height: 100px;
    width: auto;
    border-radius: 50%;
}


</style>