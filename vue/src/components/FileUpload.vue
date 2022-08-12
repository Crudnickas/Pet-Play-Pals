<template>
  <input type="file" v-on:change="onFilesChanged">
</template>

<script>
export default {
    name: 'file-upload',
    methods: {
        onFilesChanged (event) {
            const file = event.target.files[0]
            return file
        },
        onUpload() {
            
        }
    }
}
</script>

<style>

</style>