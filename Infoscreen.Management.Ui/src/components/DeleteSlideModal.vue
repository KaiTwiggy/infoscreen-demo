<template>
    <form action="">
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Delete slide?</p>
            </header>
            <section class="modal-card-body">
                <p>Are you sure you wanna delete this slide ?</p>
            </section>
            <footer class="modal-card-foot">
                <button class="button" type="button" @click="$parent.close()">Cancel</button>
                <button @click="deleteSlide(slideId)" class="button is-primary">Delete</button>
            </footer>
        </div>
    </form>
</template>

<script>
import axios from 'axios'
import * as constants from '../constants'

export default {
  name: 'DeleteSlideModal',
  props: ['slideId'],
  methods: {
    deleteSlide (slideId) {
      axios
        .delete(constants.API_BASEURL + '/api/slide/' + slideId)
        .then(function () {
          this.$emit('close')
        })
        .catch(function (error) {
          console.log('error happened' + error)
        })
    }
  }
}
</script>

<style scoped>
.modal-card {
  width: auto;
}
</style>
