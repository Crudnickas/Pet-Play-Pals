<template>
    <div id="playdates-container">
    <h1>Your Upcoming Playdates</h1>
    <div id="playdate-div" v-for="playDate in playDate" v-bind:key="playDate.Id">
        <div id="thumbnail-div"><img id="thumbnail" :src="playDate.imageURL"><br>
        <b>{{playDate.petName}}</b></div>
        <b>Date & Time:</b> {{playDate.playDateTimeDate}}<br>
        <b>Location:</b> {{playDate.playParkName}} ({{playDate.playParkAddress}})<br>
        <b>Location Notes:</b> {{playDate.playParkLocationNotes}}
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
                playDateTimeDate: 0
                
            }
        ],
            // noPets: true,
            // isLoading: true
        }
    },
    created() {
    PlayDateServices.getPlayDatesByUser(this.$store.state.user.userId).then(response => {
      this.playDate = response.data;
    //   if(!(this.playDates.length === 0)) {
    //     this.noPlayDate = false;
    //   }
    //   this.isLoading = false;
    });
  }
}
</script>

<style scoped>
#playdate-div {
    background-color: #878357;
    color: #F0EEE4;
    margin: 20px 20px;
    width: 700px;
    text-align: left;
    padding: 15px;
}
#thumbnail-div {
    text-align: center;
}
#thumbnail {
    height: 100px;
    width: auto;
}
</style>