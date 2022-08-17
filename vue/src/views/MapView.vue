<template>
<div>
  <global-menu :homePage="false"/>
  <display-map/>
  
</div>

  
</template>

<script>
import GlobalMenu from '../components/GlobalMenu.vue'
import DisplayMap from '../components/DisplayMap.vue'

export default {
     name: "map-view",
     components: {
        //  ScheduledPlayDates,
         GlobalMenu,
         DisplayMap
     }
};
</script>

<style>
img{
  border-radius: 0%;
}

</style>