<template>
    <div id="playdates-container">
    <h1>Your Upcoming Playdates</h1>
    <div id="playdate-div" v-for="playDate in playDate" v-bind:key="playDate.Id">
        <b>PlayDate ID:</b> {{playDate.playDateID}}<br><br>
        <b>Pet Name:</b> {{playDate.petName}}<br><br>
        <b>Date and Time:</b> {{playDate.playDateTimeDate}}<br><br>
        <b>Play Date Location:</b> {{playDate.playParkName}}<br><br>
        <b>Play Date Address:</b> {{playDate.playParkAddress}}<br><br>
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

</style>