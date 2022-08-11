<template>
<div>    
<global-menu/>
<form  class="form-register"  >
    <!--@submit.prevent="register" -->
    <h4>Please Enter Your Pet's Information To Register Them:</h4>
     <label for="petName" class="sr-only">Pet Name: </label>
      <input
        type="text"
        id="petName"
        class="form-control"
        placeholder="Pet Name"
        v-model="pet.name"
        v-on:change="copyPetToStore"
        required
      />
      
      <br>
     
       <label for="petAge" class="sr-only">Pet Age:  </label>
        <select name="petAge" id="petAge" v-model="pet.age"  v-on:change="copyPetToStore">
        <option disabled value = ""> Please Select one </option>
        <option value="Puppy">Puppy (under 1 year)</option>
        <option value="Adult">Adult (1 to 9 years)</option>
        <option value="Senior">Senior (10 to 13 years</option>
        <option value="Geriatric">Geriatric (14 plus years)</option>
        
    </select>
    <br>
          <label for="petSize" class="sr-only">Pet Size: </label>
        <select name="petSize" id="petSize" v-model="pet.size" v-on:change="copyPetToStore">
        <option disabled value = ""> Please Select one </option>
        <option value="Mini">Mini (under 10lbs)</option>
        <option value="Small">Small (11 to 20lbs) </option>
        <option value="Medium">Medium (21 to 50lbs)</option>
        <option value="Large">Large (greater than 50lbs)</option>
        
       
    </select>
       <br>
          <label for="petBreed" class="sr-only">Pet Breed: </label>
        <select name="petBreed" id="petBreed" v-model="pet.breed" v-on:change="copyPetToStore"> 
        <option disabled value = ""> Please Select one </option>
        <option
      v-for="breed in $store.state.dogBreeds"
      v-bind:key="breed.id">
      {{breed}}
    </option>
    </select>
      <br>
    
      <div id="petTemperamentSection">
        <label id="temperamentLabel" for="petTemperament" class="sr-only">Pet Temperament: </label>
          <multiselect id ="multiselectTempDropdown"
          v-model="temperamentArray"
          v-on:change="copyPetToStore"
          @select="changingArrayToString"
          @close="changingArrayToString"
          :options="$store.state.petTemperament"
          :multiple="true"
          :close-on-select="false"
         >
          </multiselect>
          </div>
      
    <br>

          <div>
          <label for="petEnergy" class="sr-only">Pet Energy Level : </label>
        <select name="petEnergy" id="petEnergy" v-model="pet.energy" v-on:change="copyPetToStore"> 
        <option disabled value = ""> Please Select one </option>
        <option
      v-for="energy in $store.state.petEnergy"
      v-bind:key="energy.id">
      {{energy}}
    </option>
    </select>
    </div>
    <br>
    <label for="petBio">Enter Pet Bio Here: </label>

<textarea id="petBio" name="petBio" v-model="pet.bio" v-on:change="copyPetToStore">
</textarea>
 

</form>
<!-- Try to get this to work 
<div id= "addPetSection">
      <p>Click here add another pet:</p>
      <div v-on:click="showadditionalForm">
      <img id = "addPetIcon"  src="https://cdn-icons-png.flaticon.com/512/16/16057.png"/>
      </div>
      </div>
      -->
</div>

      
  
</template>

<script>
import Multiselect from 'vue-multiselect'
import GlobalMenu from '../components/GlobalMenu.vue';


export default {
name: 'pet-register',
components:{
  Multiselect,
  GlobalMenu
},
data(){
    return{
        temperamentArray:[],
        pet:{
            petId: 0,
            name:"",
            age:"",
            size:"",
            breed:"",
            temperament: "",
            energy:"",
            bio:""
        },
        showPetForm: false,      
    }
},
methods:{
    changingArrayToString(){
        this.pet.temperament=this.temperamentArray.join(',');
        console.log(this.pet.temperamentArray);
    },
    showadditionalForm(){
        this.showPetForm = true;
    },
    copyPetToStore(){
        this.changingArrayToString;
        this.$store.commit("SETPETTOPOST", this.pet); 
    }
}
}
</script>
<style src="vue-multiselect/dist/vue-multiselect.min.css">
</style>

<style>
.multiselect{
width:20%;
color:#878357;
margin-right: 5px;
}
#petTemperamentSection{
    display:flex;
    justify-content: center;
}
</style>