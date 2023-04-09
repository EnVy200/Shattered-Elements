using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TrueSoul.Items.Whips
{
    public class AsteroidBeltMinionProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimeball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 800;
            Projectile.light = 1f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
        }
        int Timer = 0;
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.X += Main.rand.Next(-60, 60);
            Projectile.position.Y -= 250;
            base.OnSpawn(source);

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Confused, 60, false);
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void AI()
        {
            Projectile.velocity.Y = 15;
            float maxDetectRadius = 30f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 5f; // The speed at which the projectile moves towards the target

            // Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;

            // If found, change the velocity of the projectile and turn it in the direction of the target
            // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        // Finding the closest NPC to attack within maxDetectDistance range
        // If not found then returns null
        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            // Loop through all NPCs(max always 200)
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                // Check if NPC able to be targeted. It means that NPC is
                // 1. active (alive)
                // 2. chaseable (e.g. not a cultist archer)
                // 3. max life bigger than 5 (e.g. not a critter)
                // 4. can take damage (e.g. moonlord core after all it's parts are downed)
                // 5. hostile (!friendly)
                // 6. not immortal (e.g. not a target dummy)
                if (target.CanBeChasedBy())
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }


    }
}
