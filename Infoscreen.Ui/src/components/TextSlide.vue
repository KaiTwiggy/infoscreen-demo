<template>
    <div class="slide slide__text">
        <h1>TEXTSLIDE</h1>
        <h1>{{data.title}}</h1>
        <span>{{data.text}}</span>
    </div>
</template>

<script>
export default {
  name: 'TextSlide',
  props: ['data'],
  components: {}
}
</script>

<style scoped>
.slide {
  min-height: 100vh;
  width: 100%;
  background-color:black;
}
</style>
