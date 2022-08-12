<template>
    <div>
    <div v-for="n in playDates" v-bind:key="n.playDateId">{{n.petName}}</div>
    </div>
</template>

<script>
import PlayDateServices from '../services/PlayDateServices';

export default {
    name: "playdate-detail",
        data() {
        return {
        playDates: [
            {
                playDateId:0,
                creatorId:0,
                petName:"",
                playParkAddress:"",
                playParkName:"",
                PlayParkLocationNotes:"",
                PlayDateTimeDate: 0
                
            }
        ],
            // noPets: true,
            // isLoading: true
        }
    },
    created() {
    PlayDateServices.getPlayDatesByUser(this.$store.state.user.userId).then(response => {
      this.playDates = response.data;
    //   if(!(this.playDates.length === 0)) {
    //     this.noPlayDate = false;
    //   }
    //   this.isLoading = false;
    });
  }
}
</script>

<style>

</style>