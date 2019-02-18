<template>
    <div class="slide slide__image">
        <img class="image" :src="data.src" />
    </div>
</template>

<script>
export default {
  name: 'ImageSlide',
  props: ['data'],
  components: {}
}
</script>

<style>
.slide__image {
  position: relative;
  height: 100vh;
  width: 100%;
  background-color:black;
}

.image {
  max-height: 100vh;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}

</style>
