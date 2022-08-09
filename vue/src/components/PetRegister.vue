<template>
<form class="form-register" @submit.prevent="register">
    <h4>Please Enter Your Pet's Information To Register Them:</h4>
     <label for="petName" class="sr-only">Pet Name: </label>
      <input
        type="text"
        id="petName"
        class="form-control"
        placeholder="Pet Name"
        v-model="pet.name"
      />
      <br>
     
       <label for="petAge" class="sr-only">Pet Age:  </label>
        <select name="petAge" id="petAge" v-model="pet.age">
        <option disabled value = ""> Please Select one </option>
        <option value="puppy">Puppy (under 1 year)</option>
        <option value="adult">Adult (1 to 9 years)</option>
        <option value="senior">Senior (10 to 13 years</option>
        <option value="geriatric">Geriatric (14 plus years)</option>
        
    </select>
    <br>
          <label for="petSize" class="sr-only">Pet Size: </label>
        <select name="petSize" id="petSize" v-model="pet.size">
        <option disabled value = ""> Please Select one </option>
        <option value="mini">Mini (under 10lbs)</option>
        <option value="small">Small (11 to 20lbs) </option>
        <option value="medium">Medium (21 to 50lbs)</option>
        <option value="large">Large (greater than 50lbs)</option>
        
       
    </select>
       <br>
          <label for="petBreed" class="sr-only">Pet Breed: </label>
        <select name="petBreed" id="petBreed" v-model="pet.breed"> 
        <option disabled value = ""> Please Select one </option>
        <option
      v-for="breed in $store.state.dogBreeds"
      v-bind:key="breed.id">
      {{breed}}
    </option>
    </select>
      <br>
      <div id="petTemperamentSection">
        <label for="petTemperament" class="sr-only">Pet Temperament: </label>
          <multiselect id ="multiselectTempDropdown"
           @select="changingArrayToString"
          v-model="temperamentArray"
          :options="$store.state.petTemperament"
          :multiple="true"
          :close-on-select="false"
         >
          </multiselect>
          </div>
      
    <br>

          <div>
          <label for="petEnergy" class="sr-only">Pet Energy Level : </label>
        <select name="petEnergy" id="petEnergy" v-model="pet.energy"> 
        <option disabled value = ""> Please Select one </option>
        <option
      v-for="energy in $store.state.petEnergy"
      v-bind:key="energy.id">
      {{energy}}
    </option>
    </select>
    </div>
    <br>
    <label for="petBio">Enter Pet Bio Here:</label>

<textarea id="petBio" name="petBio" v-model="pet.bio">
</textarea>


</form>
  
</template>

<script>
import Multiselect from 'vue-multiselect'
export default {
name: 'pet-register',
components:{Multiselect},
data(){
    return{
        temperamentArray:[],
        pet:{
            name:"",
            age:"",
            size:"",
            breed:"",
            temperament: "",
            energy:"",
            bio:""
        }
       
    }

},
methods:{
    changingArrayToString(){
        this.pet.temperament=this.temperamentArray.toString();
        console.log(this.pet.temperament);
    }
}
}
</script>

<style src="vue-multiselect/dist/vue-multiselect.min.css">

</style>
<style>
.multiselect{
width:40%;
color:#878357;
}
#petTemperamentSection{
    display:flex;
    justify-content: flex-end;
}

</style>