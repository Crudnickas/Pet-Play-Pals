<template>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Welcome To Pet Play Pals!</h1>
      <img  src="..\assets\PawPrint.png" id = "paw-print">
      <h2>Register your account to find play dates now.</h2>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <label for="username" class="sr-only">Username: </label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <br>
      <label for="password" class="sr-only">Password: </label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <br>
       <label for="password" class="sr-only">Confirm Password: </label>
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <br>
      <div id= "addPetSection">
      <p>Click here to register a pet:</p>
      <div v-on:click="clickImage">
      <img id = "addPetIcon"  src="https://cdn-icons-png.flaticon.com/512/16/16057.png"/>
      </div>
      </div>

      <div v-if="showForm">
      <pet-register/>
      </div>
      
      <br>
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
      <br>
        <router-link :to="{ name: 'login' }">Have an account?</router-link>
    </form>
  </div>
</template>

<script>
import authService from '../services/AuthService';
import petRegister from '../components/PetRegister.vue';

export default {
  name: 'register',
  components:{
    petRegister
  },
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
      showForm: false
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
    clickImage() {
      this.showForm = !this.showForm ;
    }
  },
};
</script>

<style>
body{
  text-align: center;
}
#paw-print {
  height:400px;
  width: auto;
  
}
#addPetIcon{
 height:25px;
  width: auto;
background-color:#F0EEE4;
color: #a1a197;
margin-left: 10px;

}
#addPetSection{
  display:flex;
  justify-content: center;
  align-items: center;
}
</style>
