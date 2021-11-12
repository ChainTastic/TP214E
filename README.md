# TP214E Kevein Simon et Hamza Hajjam

# Correction Bug

- Le fichier PageCommandes.xaml était fait à partir de la balise Window qui est un controleur de WPF qui n'accepte pas la navigation d'une page à une autre qui sert plutôt à héberger des pages, donc nous avons modifié la balise Window pour Page pour permettre la navigation vers celle-ci, ainsi que son Héritage dans le fichier PageCommandes.xaml.cs la classe hérite désormais de la classe Page ce qui lui donne accès aux fonctionnalités permettant la navigation.
