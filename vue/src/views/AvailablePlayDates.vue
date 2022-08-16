<template>
<div>
<global-menu/>
<div id =availableplaydates >
<available-play-date-details/>
</div>
</div>
  
</template>

<script>
import GlobalMenu from '../components/GlobalMenu.vue';
import AvailablePlayDateDetails from '../components/AvailablePlayDateDetails.vue';

export default {
    name: "available-playDates",
  components: { 
      GlobalMenu,
      AvailablePlayDateDetails
      },


}
</script>

<style>

</style>