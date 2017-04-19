<?php
include_once 'dbconnect.php';
include_once 'functions.php';

if ($stmt = $mysqli->prepare("SELECT a.username, u.highscore
FROM uses u
JOIN accounts a ON a.email = u.email
ORDER BY u.highscore DESC 
LIMIT 5")) {
                    $stmt->execute();    // Execute the prepared query.
                    $stmt->store_result();
             
                    // get variables from result.
                    $stmt->bind_result($name, $score);
                }

                while ($stmt->fetch()) {
                    $toImplode = $toImplode.$name.":".$score."#";
                }

                echo $toImplode;

?>