<template>
<div>
    <h2 class="h3 mb-3 font-weight-normal">Your Scheduled Playdates</h2>  
    <p>You currently have no scheduled playdates</p>
    <scheduleLinks>
    <a href="#">Click Here to Schedule a Playdate</a> | <a href="#">Click Here to Browse Available Playdates</a>
    </scheduleLinks>
</div>  
</template>

<script>
export default {
name: 'scheduled-playdates'
}

</script>

<style>
a:link {
    color: #F0EEE4;
    font-weight: bold;
}

#scheduled-playdates > div > schedulelinks {

}

</style>