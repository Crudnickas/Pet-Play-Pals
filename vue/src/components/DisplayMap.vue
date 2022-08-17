<template>
  <div>
      <h3>{{currentMarker}}</h3>
      <h4>{{currentMarkerNotes}}</h4>
          <gmap-map
      :center="center"
      :zoom="mapZoom"
       :options="{minZoom: 9, maxZoom: 11}"
      style="width:100%;  height: 555px;">
      <gmap-marker
        :key="index"
        v-for="(gmp, index) in locations"
        :position="gmp"
        @click="center=gmp; currentMarker = gmp.label; currentMarkerNotes = gmp.notes; mapZoom = 12"

        :label="{text: gmp.label, color: 'black', fontWeight: 'bold'}"
        
      ></gmap-marker>
    </gmap-map>
    <input type="text" v-model="testPlace" placeholder="Enter Address or City,State">
    <input type ="button" value="Go to Location" @click="alertFromAddress(testPlace)">

  </div>
</template>

<script>
import googleService from '../services/GoogleService'

export default {
      name: "display-map",
data() {
    return {
      center: { 
          lat: 39.7837304, 
          lng: -100.4458825 
      },
      locations: [],
      currentLocation: null,
      latAndLong: {
          lat: 0,
          lng: 0
      },
      testPlace: "",
      currentMarker: "None-Selected",
      currentMarkerNotes: "",
      mapZoom: 11,
      style: {
        
      }
    };
  },
 created() {
     
    googleService.getLatLongFromAddress("ohio")
      .then((response) => {
        this.latAndLong.lat = response.data.results[0].geometry.location.lat;
        this.latAndLong.lng = response.data.results[0].geometry.location.lng;

      });
 },
  mounted() {
    this.setLocationLatLng();
    
  },
 
  methods: {

    alertFromAddress(address){
         googleService.getLatLongFromAddress(address)
      .then((response) => {
        this.center.lat = response.data.results[0].geometry.location.lat;
        this.center.lng = response.data.results[0].geometry.location.lng;
        alert(`${response.data.results[0].geometry.location.lat}, ${response.data.results[0].geometry.location.lng}`);

      })
      .catch(() => {
          alert("Please Enter a Valid Address/Location")
      });
    },
    setPlace(loc) {
      this.currentLocation = loc;
    },
    setLocationLatLng: function() {
        navigator.geolocation.getCurrentPosition(geolocation => {
          this.center = {
            lat: geolocation.coords.latitude,
            lng: geolocation.coords.longitude
          };
        });
 
        this.locations = [
          {
              lat: 39.7837304,
              lng: -100.4458825,
              label: 'United States',
              notes: ""
          },
          {
              lat: 38.6529545,
              lng: -90.2411166,
              label: 'St. Louis',
              notes: ""
          },
          {
              lat: 41.3828939,
              lng: 2.1774322,
              label: 'Barcelona',
              notes: ""
          },
          {
              lat: -10.3333333,
              lng: -53.2,
              label: 'Brazil',
              notes: ""
          }
      ];
      this.$store.state.playDateLocations.forEach(location => {
          let locationToAdd = {
              lat: 0,
              lng: 0,
              label: location.PlayParkName,
              notes: location.PlayParkLocationNotes
          }
    googleService.getLatLongFromAddress(location.PlayParkAddress)
      .then((response) => {
        locationToAdd.lat = response.data.results[0].geometry.location.lat;
        locationToAdd.lng = response.data.results[0].geometry.location.lng;
      });
      this.locations.push(locationToAdd);
      });
 
    }
  }

}
</script>

<style>

</style>