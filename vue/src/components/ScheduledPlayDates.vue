<template>
<div id="your-scheduled-playdates">
    <h2 class="h3 mb-3 font-weight-normal">Your Scheduled Playdates</h2> 
  <div id="isLoading" v-if="isLoading"><img src="https://c.tenor.com/qmg1JQ82uWAAAAAj/oxo-perros-cute.gif" /></div>
  <noPlatDateSection v-show="!isLoading"><div id="noPlayDate" v-show="noPlayDate">You currently have no registered pets</div>
    <p>You currently have no scheduled playdates</p>
  </noPlatDateSection>
   
    <div>
    <a href="#">Click Here to Schedule a Playdate</a><br><a href="#">Click Here to Browse Available Playdates</a>
    </div>
</div>  
</template>

<script>
import PlayDateServices from '../services/PlayDateServices';

export default {
name: 'scheduled-playdates',
data(){
    return{
        playDate: [
            {
                playDateId:0,
                creatorId:"",
                petName:"",
                playParkAddress:"",
                playParkName:"",
                PlayParkLocationNotes:"",
                PlayDateTimeDate: ""
                
            }
            
        ],
         noPlayDate: true,
        isLoading: true
    }

},
  created() {
    PlayDateServices.getPlayDatesByUser(this.$store.state.user.userId).then(response => {
      this.playDate = response.data;
      if(!(this.playDate.length === 0)) {
        this.noPlayDate = false;
      }
      this.isLoading = false;
    });
  }
}

</script>

<style scoped>
a:link {
    color: #F0EEE4;
    font-weight: bold;
}

#your-scheduled-playdates {
    display: flex;
    flex-direction: column;
    align-items: space-between;
}
</style>