<template>
<div>
<global-menu/>
<scheduled-play-dates/>
<schedule-playdate-form/>
</div>

  
</template>

<script>
import ScheduledPlayDates from '../components/ScheduledPlayDates.vue'
import SchedulePlaydateForm from '../components/SchelduePlaydateForm.vue'
import GlobalMenu from '../components/GlobalMenu.vue'

export default {
     name: "play-dates",
     components: {
         ScheduledPlayDates,
         SchedulePlaydateForm,
         GlobalMenu

     }
};
</script>

<style>

</style>