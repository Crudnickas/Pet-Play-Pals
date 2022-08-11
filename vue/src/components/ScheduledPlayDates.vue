<template>
<div id="your-scheduled-playdates">
    <div><h2 class="h3 mb-3 font-weight-normal">Your Scheduled Playdates</h2>  
    <p>You currently have no scheduled playdates</p>
    </div>
    <div>
    <a href="#">Click Here to Schedule a Playdate</a><br><a href="#">Click Here to Browse Available Playdates</a>
    </div>
</div>  
</template>

<script>
export default {
name: 'scheduled-playdates'
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