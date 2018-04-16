<template>
<div class="keep">
    <div class="row">
        <div v-for="item in keeps">
            <div class="col-sm-3">
                <div class="panel panel-info">
                    <div class="panelheading">
                        <div class="pull-right" v-if="item.userId == user.id">
                                <button @click="deleteKeep(item.id)">
                                        <i class="fa fa-trash"></i>
                                    </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
</script>

<style>

</style>