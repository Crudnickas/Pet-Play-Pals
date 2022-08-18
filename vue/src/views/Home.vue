<template>
  <div>
  <global-menu :homePage="true"/>
 
    <div id="homepage-components">
    
    <div id="registered-pets">
    <registered-pets/> 
    </div>
    
    <div id="scheduled-playdates">
    <scheduled-play-dates :key="$route.fullPath"/>
    </div>
    
    </div>
    </div>
</template>

<script>
import RegisteredPets from '../components/RegisteredPets.vue';
import ScheduledPlayDates from '../components/ScheduledPlayDates.vue';
import GlobalMenu from '../components/GlobalMenu.vue';


export default {
  name: "home",
  data() {
    return {
      showForm: false
      }
    },
  components: {
    RegisteredPets,
    ScheduledPlayDates,
    GlobalMenu
  },
  methods: {
    showHideMenu() {
      this.showForm = !this.showForm;
    }
  },
};
</script>

<style>
#homepage-components {
  display: flex;
  justify-content: center;
}

#registered-pets, #scheduled-playdates {
  background-color: rgb(137, 155, 83);;
  color: white;
  width: 500px;
  margin: 75px;
}
</style>
