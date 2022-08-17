<template>
    <div id="playdates-container">
    <h1>Your Playdates</h1>
    <div id="no-playdates-div" v-show="noPlayDates">You Currently Have No Playdates</div>
    <div id="playdate-div" v-for="playDate in playDate" v-bind:key="playDate.Id">
        <h3 style="text-align:center"><b>Status:</b> <b>{{playDate.status}}</b></h3>
        <div id="thumbnail-div"><img id="thumbnail" :src="playDate.imageURL"><br>
        <b>{{playDate.petName}}</b></div>
        <b>Date & Time:</b> {{playDate.playDateTimeDate}}<br>
        <b>Location:</b> {{playDate.playParkName}} ({{playDate.playParkAddress}})<br>
        <b>Location Notes:</b> {{playDate.playParkLocationNotes}}<br>
        <button class="cancelbutton" type="cancel" v-show="playDate.status!='Cancelled'" v-on:click.prevent="UpdatingStatusofPlayDateToCancel(playDate.playDateID)">Cancel Playdate</button>
       

    </div>
    </div>
</template>

<script>
import PlayDateServices from '../services/PlayDateServices';

export default {
    name: "playdate-detail",
        data() {
        return {
        playDate: [
            {
                playDateID:0,
                imageURL: "",
                creatorID:0,
                petName:"",
                playParkAddress:"",
                playParkName:"",
                playParkLocationNotes:"",
                playDateTimeDate: 0,
                status:"",
                
            }
        ],
        playDateRelationshipToPut: {
                userID: 0,
                playDateID: 0,
                petID: 0,
                playDateStatus: "Cancelled"
            },
        noPlayDates: true
        }
    },
    methods:{
       UpdatingStatusofPlayDateToCancel(playDateID){
            this.playDateRelationshipToPut.playDateID = playDateID;
            PlayDateServices.updateUserPlayDateStatus(this.playDateRelationshipToPut)
            .then((response)=> {
                if(response.status === 200) {
                    alert("Playdate has been successfully cancelled")
                     this.$router.push({
                        path: '/',
                         });

    }
            })
            ;
       }
    },
    created() {
    PlayDateServices.getPlayDatesByUser(this.$store.state.user.userId).then(response => {
      this.playDate = response.data;
       if(!(this.playDate.length === 0)) {
         this.noPlayDates = false;
       }
    //   this.isLoading = false;
    });
  }
}
</script>

<style scoped>
.cancelbutton{
    background-color: #E7E7E7; 
    color: black; 
    border-radius: 10px;
    text-align: center;
    justify-items: center;
    align-items: center;
   

}
#playdate-div, #no-playdates-div {
    background-color: #878357;
    color: #F0EEE4;
    margin: 20px 20px;
    width: 700px;
    text-align: left;
    padding: 15px;
}

#no-playdates-div {
    text-align: center;
}

#thumbnail-div {
    text-align: center;
}
#thumbnail {
    height: 100px;
    width: auto;
}

</style>