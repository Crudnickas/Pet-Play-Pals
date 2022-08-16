<template>
<div>
     <div id="playdates-container">
    <h1>Select a PlayDate to Join:</h1>
    <div id="playdate-div">
        <div id="thumbnail-div"><img id="thumbnail"><br>
        <b></b></div>
        <b>Date & Time:</b> <br>
        <b>Location:</b> <br>
        <b>Location Notes:</b> 
        <br>
        <button id= "joindatebutton" type="submit" v-on:click.prevent="submitPlaydate">Join Play Date</button>&nbsp; 
    </div>
</div>
</div>
  
</template>

<script>
export default {
    name: "available-play-date-details"

}
</script>

<style scoped>
#playdate-div {
    background-color: #878357;
    color: #F0EEE4;
    margin: 20px 20px;
    width: 700px;
    text-align: left;
    padding: 15px;
}
#thumbnail-div {
    text-align: center;
}
#thumbnail {
    height: 100px;
    width: auto;
}


</style>