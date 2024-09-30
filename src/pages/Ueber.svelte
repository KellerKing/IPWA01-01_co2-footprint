<script>
    import { leserichtung } from "../store";

    let direction;
    leserichtung.subscribe((value) => {
        direction = value;
    });
</script>


<div dir = {direction}>

</div>
