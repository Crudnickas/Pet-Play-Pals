<template>
<form action="">
<h2>Schedule a PlayDate:</h2>
<div id="selectYourPet">
<multiselect  id="pet" v-for="pet in pet" v-bind:key="pet.petId">

</multiselect>
</div>

<button class = "submitButton" type="submit" value="Submit" v-on:click="addNewPet">Submit</button>
<button type="cancel" value="Cancel" v-on:click ="cancelButton">Cancel</button>

</form>

  
</template>

<script>
import Multiselect from 'vue-multiselect'

export default {
name: 'schedule-playdate-form',
components:{
    Multiselect
}
}
</script>

<style>

</style>