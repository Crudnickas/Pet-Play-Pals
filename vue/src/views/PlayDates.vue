<template>
<div>
<global-menu/>
<div id="playdates">
    <scheduled-play-dates-detail/>
<schedule-playdate-form/></div>
</div>

  
</template>

<script>
// import ScheduledPlayDates from '../components/ScheduledPlayDates.vue'
import SchedulePlaydateForm from '../components/SchelduePlaydateForm.vue'
import GlobalMenu from '../components/GlobalMenu.vue'
import ScheduledPlayDatesDetail from '../components/ScheduledPlayDatesDetail.vue';

export default {
     name: "play-dates",
     components: {
        //  ScheduledPlayDates,
         SchedulePlaydateForm,
         GlobalMenu,
         ScheduledPlayDatesDetail
     }
};
</script>

<style>
#playdates {
    display: flex;
    justify-content: space-evenly;
}
</style>