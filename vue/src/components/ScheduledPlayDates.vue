<template>
<div id="bacon-salad">
    <div id="playdates-top">
    <h2 class="h3 mb-3 font-weight-normal">Your Scheduled Playdates:</h2>
        <div id="isLoading" v-if="isLoading"><img src="https://c.tenor.com/qmg1JQ82uWAAAAAj/oxo-perros-cute.gif" /></div>
        <div id="noPlayDate" v-show="noPlayDate">You currently have no scheduled Playdates</div>
        <div v-show="!noPlayDate">
        <div v-for="pd in playDate" v-bind:key="pd.Id"><b><em>{{pd.playParkName}},</em></b> {{formatDate(pd.playDateTimeDate)}} ({{pd.petName}})
        <!-- {{pd.playDateTimeDate}}  -->
    
        </div>
        </div>
    </div>
    <br><br><br>
    <div id="see-all-link">
        <router-link v-bind:to="{ name: 'playdates' }">Click Here to see All Playdates or Schedule a Playdate</router-link>
        <br>
        <router-link v-bind:to="{name: 'available-playDates'}"> Click Here to Browse Available Playdates</router-link>
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
                 imageURL: "",
                creatorId:0,
                petName:"",
                playParkAddress:"",
                playParkName:"",
                PlayParkLocationNotes:"",
                PlayDateTimeDate: 0,
                status: ""
                
            }
            
        ],
        noPlayDate: true,
        isLoading: false
    }

},
  created() {
    PlayDateServices.getPlayDatesByUser(this.$store.state.user.userId).then(response => {
      this.playDate = response.data;
      this.playDate=this.playDate.filter((element)=>{
          return element.status == 'Joined';
      })
      if(!(this.playDate.length === 0)) {
        this.noPlayDate = false;
      }
      this.isLoading = false;
    });
  },
methods: {
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
}
}

</script>

<style scoped>
a:link {
    color: #F0EEE4;
    font-weight: bold;
}
a:visited{
    color:rgb(78, 41, 14)
}

#bacon-salad {
    display: flex;
    flex-direction: column;
}
</style>