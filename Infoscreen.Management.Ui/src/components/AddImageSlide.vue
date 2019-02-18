<template>
    <div>
      <section>
        <b-field label="Image Url">
            <b-input placeholder="URL" type="url"></b-input>
        </b-field>
      </section>
      {{SlideData}}
    </div>
</template>

<script>
let SlideData = {}
export default {
  name: 'AddImageSlide',
  props: ['SlideData'],
  data: function () {
    return { imageData: SlideData }
  }
}
</script>

<style scoped>

</style>
