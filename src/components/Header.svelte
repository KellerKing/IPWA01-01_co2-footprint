<script>
    import src from "../assets/logo_iu.svg";
</script>
<header class="bg-gradient-to-b from-black">  
    <nav class="flex">
        <img {src} alt="Logo" class="w-16 md:w-32 lg:w-48 p-6"/>
        <div class = "flex justify-between w-full mt-10">
            <a href="#">Startseite</a>
            <a href="#">Co2 Fußabdruck im vergleich</a>
            <a href="#" class="mr-6">Über die Seite</a>
        </div>
    </nav>
        <!--<img {src} alt="Logo"/>-->
</header>


<style>
.header {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    padding: 20px 100px;
    background-color: lightblue;
    display: flex;
    justify-content: space-between;
    align-items: center;
    z-index: 100;
}

.navigation a {
    position: relative;
    font-size: 18px;
    color: white;
    font-weight: 500;
    text-decoration: none;
    margin-left: 40px;
}

.navigation a::before {
    content: '';
    position: absolute;
    top: 100%;
    left: 0;
    height: 3px;
    width: 0%;
    background-color: lightgreen;
    transition: 200ms;
}

.navigation a:hover::before {
    width: 100%;
}

</style>