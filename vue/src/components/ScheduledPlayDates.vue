<template>
<div id="your-scheduled-playdates">
    <h2 class="h3 mb-3 font-weight-normal">Your Scheduled Playdates:</h2>
    <div id="isLoading" v-if="isLoading"><img src="https://c.tenor.com/qmg1JQ82uWAAAAAj/oxo-perros-cute.gif" /></div>
<div v-show="!isLoading"><div id="noPlayDate" v-show="noPlayDate">You currently have no scheduled Playdates</div>
</div>
<div id = "playdate" v-show="!noPlayDate">
    <div id="playDate" v-for="playDate in playDate" v-bind:key="playDate.Id"><b><em>{{playDate.playParkName}},</em></b> {{playDate.playDateTimeDate}} ({{playDate.petName}})</div>
</div>
    <div>
    <router-link v-bind:to="{name:'playdates'}">Click Here to see All Scheduled Playdates</router-link> <br><a href="#">Click Here to Browse Available Playdates</a>
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
                creatorId:0,
                petName:"",
                playParkAddress:"",
                playParkName:"",
                PlayParkLocationNotes:"",
                PlayDateTimeDate: 0
                
            }
            
        ],
        noPlayDate: true,
        isLoading: false
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